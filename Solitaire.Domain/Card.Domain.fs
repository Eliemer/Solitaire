namespace Solitaire.Domain

module Card =

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

    [<Struct>]
    [<NoComparison>]
    type Card = { Suit : Suit; Rank : Rank }

    // The first element of the list is the top of the stack
    type Deck = { Cards : Card list }
    type Pile = { Cards : Card list }
    type Foundation = { Cards : Card list; Suit : Suit }
    type Talon = { Cards : Card list }

    type Stack =
        | Deck of Deck
        | Pile of Pile
        | Foundation of Foundation
        | Talon of Talon
    
    let StandardDeck: Deck =
        {
            Cards =
                [
                    let combos =
                        List.allPairs
                            [ Clubs; Diamonds; Hearts; Spades ]
                            [ Ace; Two; Three; Four; Five; Six; Seven; Eight; Nine; Ten; Jack; Queen; King ]

                    for (suit, rank) in combos do
                        { Suit = suit; Rank = rank }
                ]
        }

    type Table =
        {
            Deck: Deck
            Talon: Talon
            Piles: Pile array
            Foundations: Foundation array
        }