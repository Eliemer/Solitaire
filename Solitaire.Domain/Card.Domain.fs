namespace Solitaire.Domain

module Card =

    type Orientation =
        | FaceUp
        | FaceDown

    [<NoComparison>]
    [<Struct>]
    type Color =
        | Red
        | Black

    [<Struct>]
    [<NoComparison>]
    type Suit =
        | Clubs
        | Diamonds
        | Hearts
        | Spades

        member this.Color =
            match this with
            | Spades
            | Clubs -> Black
            | Diamonds
            | Hearts -> Red

    [<Struct>]
    type Rank =
        | Ace
        | Two
        | Three
        | Four
        | Five
        | Six
        | Seven
        | Eight
        | Nine
        | Ten
        | Jack
        | Queen
        | King
        with
        member this.Incr (): Rank = 
            match this with
            | Ace -> Two
            | Two -> Three
            | Three -> Four
            | Four -> Five
            | Five -> Six
            | Six -> Seven
            | Seven -> Eight
            | Eight -> Nine
            | Nine -> Ten
            | Ten -> Jack
            | Jack -> Queen
            | Queen -> King
            // do we circle, or not?
            | King -> Ace

    [<Struct>]
    [<NoComparison>]
    type Card = { Suit : Suit; Rank : Rank; Orientation: Orientation }

    // The first element of the list is the top of the stack
    type Deck = { Cards : Card list }
    type Pile = { Cards : Card list }
    type Foundation = { Cards : Card list }
    type Talon = { Cards : Card list }

    type Stack =
        | Deck of Deck
        | Pile of Pile
        | Foundation of Foundation
        | Talon of Talon
    
    let STANDARD_DECK: Deck =
        {
            Cards =
                [
                    let combos =
                        List.allPairs
                            [ Clubs; Diamonds; Hearts; Spades ]
                            [ Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King ]

                    for (suit, rank) in combos do
                        { Suit = suit; Rank = rank; Orientation = FaceDown }
                ]
        }

    type Table =
        {
            Deck: Deck
            Talon: Talon
            Piles: Pile array
            Foundations: Foundation array
        }