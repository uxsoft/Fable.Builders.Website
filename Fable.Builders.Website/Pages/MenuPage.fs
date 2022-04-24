module Fable.Builders.Website.Pages.MenuPage

open Fable.Builders.React
open Fable.Builders.AntDesign
open Fable.AntDesign.Examples.Components.Example
open Fable.Import
open Feliz

let view model =
    Space {
        Example {
            name "Data"
            sourceUrl "Pages/MenuPage.fs"
            sourceRange (16, 24)
            
            Menu {
                MenuItem { label (str "Menu Item 1") }
            }
        }  
    }