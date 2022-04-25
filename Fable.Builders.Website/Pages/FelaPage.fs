module Fable.Builders.Website.Pages.FelaPage

open Fable.Builders.Fela
open Fable.Builders.React
open Fable.Builders.AntDesign
open Feliz

[<ReactComponent>]
let TestComponent () =
    let css = Fela.useFela ()
    let cls = css [
        style.backgroundColor color.red
        style.hover [
            style.backgroundColor color.blue
        ]
    ]
    
    div {
        className cls
        str "asd"
    }

let view model =
    Fela.RendererProvider {
        renderer (Fela.createRenderer())
        
        TestComponent ()
    }