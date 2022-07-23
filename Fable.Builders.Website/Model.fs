module Fable.AntDesign.Examples.Model

open Fable.Core

[<StringEnum>]
type Page =
    | SyntaxPage
    | ButtonPage
    | IconPage
    | TypographyPage 
    | DividerPage 
    | GridPage 
    | LayoutPage
    | MenuPage
    | StepsPage 
    | FormPage 
    | SelectPage 
    | ListPage 
    | CollapsePage 
    | SegmentedPage 
    | TablePage 
    | TimelinePage 
    | NotificationPage 
    | ProgressPage 
    | ChartsPage 
    | DnDKitPage 
    | ReactBeautifulDnDPage
    | FelaPage
    | RouterPage
type Model =
    { Page: Page
      IsLoggingIn: bool }

type Msg =
    | Navigate of Page
    | BeginLogin of string * string
    | EndLogin

let init () =
    { Page = Page.ButtonPage
      IsLoggingIn = false }, []
    
let update (msg: Msg) (model: Model) =
    match msg with
    | Navigate page -> { model with Page = page }, []
    | BeginLogin (username, password) ->
        { model with IsLoggingIn = true },
        [ fun dispatch ->
            async {
                Browser.Dom.console.log $"Logging in with {username}:{password}"
                do! Async.Sleep 2000
                dispatch EndLogin
            } |> Async.StartImmediate ]
    | EndLogin -> { model with IsLoggingIn = false }, []