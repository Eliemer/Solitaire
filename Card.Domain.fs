namespace Solitaire.Domain

module Cards =
    open Microsoft.FSharp.Reflection

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

    type Card = { Suit : Suit; Rank : Rank }

    type Spot =
        // Where all 52 cards come from
        | Deck
        // The play area piles
        | Pile
        // Where the suits are built up
        | Foundation of Suit
        | Talon

    // The first element of the list is the top of the stack
    type Stack = { Cards : Card list; Spot : Spot }

    let StandardDeck =
        {
            Stack.Spot = Deck
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
