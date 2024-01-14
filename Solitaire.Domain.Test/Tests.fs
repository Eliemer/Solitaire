module Tests

open Xunit
open FsCheck
open FsCheck.Xunit

open Solitaire.Domain.Card
open Solitaire.Domain.Logic

[<Fact>]
let ``My test`` () = Assert.True(true)

[<Properties>]
module StackTests =

    [<Fact>]
    let ``Adding a King to a Pile increases the height of the stack`` () =
        let pile : Stack = Pile { Cards = [] }

        let card : Card =
            {
                Suit = Diamonds
                Rank = King
                Orientation = FaceUp
            }

        Stack.addToStack card pile
        |> Result.map (fun pileAfter ->
            let cards = (Stack.getCards pile)
            let cardsAfter = (Stack.getCards pileAfter)
            cards.Length + 1 = cardsAfter.Length)
        |> Result.isOk
        |> Assert.True

    [<Property>]
    let ``Stack getCards reflects the same list of cards`` (cards : Card list) =
        let stack = Pile { Cards = cards }
        cards = Stack.getCards stack

    [<Property>]
    let ``You can always remove a card from any stack`` (stack : Stack) =
        (Stack.getCards stack).Length > 0
        ==> (Stack.removeFromStack stack |> Result.isOk)

    [<Fact>]
    let ``Check pile for ascending run``() =
        let run =
            [
                { Suit = Diamonds; Rank = Ace; Orientation = FaceUp }
                { Suit = Spades  ; Rank = Two; Orientation = FaceUp }
                { Suit = Hearts; Rank = Three; Orientation = FaceUp }
                // Not part of ascending run
                { Suit = Clubs ; Rank = King; Orientation = FaceUp }
                // Facedown card
                { Suit = Clubs ; Rank = Jack; Orientation = FaceDown } 
            ]

        let pile = { Pile.Cards = run }
        Stack.ascendingRunInPile pile = List.take 3 run