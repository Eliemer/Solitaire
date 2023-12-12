namespace Solitaire.Domain

open Solitaire.Domain.Cards

module Logic =
    type StackError =
        | CantAddToStack
        | NoCardToRemove

    module Suit =
        let sameColor (a : Suit) (b : Suit) = a.Color = b.Color

    module Rank =
        [<Literal>]
        let Ace = "Ace"

        [<Literal>]
        let Two = "Two"

        [<Literal>]
        let Three = "Three"

        [<Literal>]
        let Four = "Four"

        [<Literal>]
        let Five = "Five"

        [<Literal>]
        let Six = "Six"

        [<Literal>]
        let Seven = "Seven"

        [<Literal>]
        let Eight = "Eight"

        [<Literal>]
        let Nine = "Nine"

        [<Literal>]
        let Ten = "Ten"

        [<Literal>]
        let Jack = "Jack"

        [<Literal>]
        let Queen = "Queen"

        [<Literal>]
        let King = "King"

        let toString (r : Rank) : string =
            match r with
            | Rank.Ace -> Ace
            | Rank.Two -> Two
            | Rank.Three -> Three
            | Rank.Four -> Four
            | Rank.Five -> Five
            | Rank.Six -> Six
            | Rank.Seven -> Seven
            | Rank.Eight -> Eight
            | Rank.Nine -> Nine
            | Rank.Ten -> Ten
            | Rank.Jack -> Jack
            | Rank.Queen -> Queen
            | Rank.King -> King

        let parse (s : string) : Result<Rank, string> =
            match s.ToLowerInvariant() with
            | Ace -> Ok Rank.Ace
            | Two -> Ok Rank.Two
            | Three -> Ok Rank.Three
            | Four -> Ok Rank.Four
            | Five -> Ok Rank.Five
            | Six -> Ok Rank.Six
            | Seven -> Ok Rank.Seven
            | Eight -> Ok Rank.Eight
            | Nine -> Ok Rank.Nine
            | Ten -> Ok Rank.Ten
            | Jack -> Ok Rank.Jack
            | Queen -> Ok Rank.Queen
            | King -> Ok Rank.King
            | e -> Error $"{e} is not a valid card rank"

    module Stack =

        let getCards (stack: Stack) : Card list =
            match stack with
            | Deck { Cards = cards }
            | Talon { Cards = cards }
            | Pile { Cards = cards }
            | Foundation { Cards = cards } -> cards

        let addToStack (c : Card) (stack : Stack) : Result<Stack, StackError> =
            match stack with
            // TODO: Figure out what to do about restarting or flipping the talon back into the deck
            | Deck { Cards = _ } -> Error CantAddToStack
            | Talon { Cards = cards } -> Talon { Cards = c :: cards } |> Ok
            | Pile { Cards = cards } ->
                match cards with
                | [] -> Pile { Cards = [ c ] } |> Ok
                | top :: rest ->
                    if Suit.sameColor top.Suit c.Suit || top.Rank <= c.Rank then
                        Error CantAddToStack
                    else
                        Pile { Cards = c :: top :: rest } |> Ok
            | Foundation { Cards = cards; Suit = targetSuit }->
                if c.Suit <> targetSuit then
                    Error CantAddToStack
                else
                    match cards with
                    | [] -> 
                        if c.Rank = Ace then 
                            Foundation { Cards = [ c ]; Suit = targetSuit } |> Ok
                        else
                            Error CantAddToStack
                    | top :: rest ->
                        if c.Rank < top.Rank then
                            Foundation { Cards = c :: top :: rest; Suit = targetSuit } |> Ok
                        else
                            Error CantAddToStack

        let removeFromStack (stack : Deck) : Result<Card * Deck, StackError> =
            match stack.Cards with
            | [] -> Error NoCardToRemove
            | top :: rest -> Ok(top, { stack with Cards = rest })
