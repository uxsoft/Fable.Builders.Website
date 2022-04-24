module Fable.AntDesign.Examples.Pages.ButtonPage

open Fable.AntDesign.Examples.Components.Example
open Fable.Builders.AntDesign

let view model =
    Example {
        name "Button Types"
        sourceUrl "Pages/ButtonPage.fs"
        sourceRange (12, 19)
        
        Space {
            Button {
                "Button"
            }
            Button {
                buttonType ButtonType.Primary
                "Primary Button"
            }
        }
    }