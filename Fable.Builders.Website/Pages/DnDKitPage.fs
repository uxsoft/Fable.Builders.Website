module Fable.AntDesign.Examples.Pages.DnDKitPage

open Fable.Builders.DndKit
open Fable.Builders.React
open Fable.Builders.AntDesign
open Fable.AntDesign.Examples.Components.Example
open Fable.Import
open Feliz

type SelectOption =
    { label: string; value: string }
    
[<ReactComponent>]
let Droppable (children: ReactElement list) =
    let d = DnD.useDroppable "droppable-1"
    div {
        ref d.setNodeRef
        style [
            if d.isOver then style.backgroundColor color.green else style.backgroundColor color.blue
            style.width 400
            style.height 300
        ]
        yield! children
    }

[<ReactComponent>]
let Draggable () =
    let d = DnD.useDraggable "draggable-1"
    
    button {
        ref d.setNodeRef
        style [
            if d.transform.IsSome then
                style.transform [ transform.translateX d.transform.Value.x
                                  transform.translateY d.transform.Value.y ]
            style.width 100
            style.height 50
        ]
        str "Draggable"
    }

let view model =
    Space {
        Example {
            name "Basic Example"
            sourceUrl "Pages/DnDPage.fs"
            sourceRange (16, 24)
            
            DnD.DndContext {
                Draggable ()
                Droppable [
                    str "Droppable"
                ]
            }
        }
    }