module Fable.Builders.Website.Pages.RouterPage

open Fable.AntDesign.Examples.Components.Example
open Fable.Builders
open Fable.Builders.React
open Fable.Builders.AntDesign
open Fable.Builders.ReactRouterDom
open Fable.Core
open Fable.Core.JsInterop
open Feliz


[<ReactComponent>]
let ParamNameComponent () =
    let parameters = Fable.Builders.ReactRouterDom.useParams<{| paramName : string |}>()
    str $"paramName = {parameters.paramName}"

let view model =
    Space {
        Example {
            name "Parameters"
            sourceUrl "Pages/RouterPage.fs"
            sourceRange (16, 24)
            
            ParamNameComponent ()
        }
    }
