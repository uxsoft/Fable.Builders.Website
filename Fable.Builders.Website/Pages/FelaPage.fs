module Fable.Builders.Website.Pages.FelaPage

open Fable.Builders.Emotion
open Fable.Builders.Fela
open Fable.Builders.React
open Fable.Builders.AntDesign

open Fable.Core
open Fable.Core.JsInterop
open Feliz

[<ReactComponent>]
let FelaComponent () =
    let css = Fela.useFela ()
    let cls = css [
        style.backgroundColor color.red
        style.hover [
            style.backgroundColor color.blue
        ]
    ]
    
    div {
        className cls
        str "Fela"
    }
    
[<ReactComponent>]
let EmotionComponent () =
    div {
        css [
            style.backgroundColor color.red
            style.hover [
                style.backgroundColor color.blue
            ]
        ]
        str "Emotion"
    }



let view model =
    Content {
        Fela.RendererProvider {
            renderer (Fela.createRenderer())
            
            FelaComponent ()
        }
        EmotionComponent ()
    }