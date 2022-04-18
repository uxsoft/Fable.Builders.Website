module Fable.AntDesign.Examples.Pages.ReactBeautifulDnDPage

open Fable.Builders.ReactBeautifulDnD
open Fable.Builders.React
open Fable.Builders.AntDesign
open Fable.AntDesign.Examples.Components.Example
open Fable.Builders.ReactBeautifulDnD.Types
open Fable.Import
open Feliz

let initialTasks =
    [| "task1"; "task2"; "task3"; "task4"; "task5" |]

let handleDragEnd (tasks: string array) (setTasks: string array -> unit) (dropResult: DropResult) (provided: ResponderProvided) =
    Browser.Dom.console.log dropResult
    if dropResult.destination.IsSome then
        let newList = Seq.move dropResult.source.index dropResult.destination.Value.index tasks
        Browser.Dom.console.log newList
        setTasks newList

[<ReactComponent>]
let Task task i =
    DnD.Draggable {
        draggableId task
        index i
        key $"draggable-{task}"
                
        children (fun provided snapshot rubric ->         
            div {
                spread provided.draggableProps
                spread provided.dragHandleProps
                ref provided.innerRef
                div {
                    style [
                        style.width 200
                        style.height 48
                        style.border(1, borderStyle.solid, color.gray)
                        style.backgroundColor color.white
                        style.padding 6
                    ]
    
                    str task
                }
            })
    }

[<ReactComponent>]
let View () =
    let tasks, setTasks = React.useState initialTasks
    Space { 
        Example {
            name "Basic Example"
            sourceUrl "Pages/ReactBeautifulDnDPage.fs"
            sourceRange (16, 24)
            
            DnD.DragDropContext {
                onDragEnd (fun a b -> handleDragEnd tasks setTasks a b) 
                div {
                    className "column"
                    DnD.Droppable {
                        droppableId "column1"
                        children (fun provided snapshot ->
                            div {                                
                                ref provided.innerRef
                                spread provided.droppableProps
                                
                                for task, index in tasks |> Seq.mapi (fun i t -> t, i) do
                                    Task task index
                                    
                                provided.placeholder.Value
                            })
                    }
                }
            }
        }
    }