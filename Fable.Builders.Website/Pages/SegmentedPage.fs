module Fable.Builders.Website.Pages.SegmentedPage

open Fable.Builders.React
open Fable.Builders.AntDesign
open Fable.AntDesign.Examples.Components.Example
open Fable.Import
open Feliz

let view model =
    Space {
        Example {
            name "Data"
            sourceUrl "Pages/SegmentedPage.fs"
            sourceRange (16, 24)
            
            Segmented {
                options [| "Source"; "Split"; "Preview" |]
            }

        }  
    }