module Tests

open Xunit
open FsCheck
open FsCheck.Xunit

open Solitaire.Domain.Card

[<Fact>]
let ``My test`` () =
    Assert.True(true)

// [<Properties>]
// module CardTests =

//     [<Property>]
//     let ````