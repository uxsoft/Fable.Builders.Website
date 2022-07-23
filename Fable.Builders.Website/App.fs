module App

open System
open Fable.AntDesign.Examples.Pages
open Fable.AntDesign.Examples.Model
open Fable.Builders.AntDesign
open Fable.Builders.React
open Fable.Builders.ReactRouterDom
open Fable.Builders.Website.Pages
open Feliz
open Elmish
open Elmish.React
open Elmish.HMR

let notFound =
    Result {
        status ResultStatus.NotFound
        title (str "Page not found")
        subTitle (str "Try a different one!")
    }
    
let PageMenuItem (page: Page) (name: string) =
    MenuItem {
        key (string page)
        label (Link {
            href (string page)
            str name
        })
    }


let App (model: Model) dispatch =
    Layout {
        Header {
            style [
                style.height 66
                style.backgroundColor color.white
                style.zIndex 1
                style.boxShadow(0, 1, 4, "rgba(0, 21, 41, 0.08)") ]
                
            Space {
                img {
                    style [
                        style.float'.left
                        style.margin(12, 0, 0, -32)
                        style.height 40 ]
                    src "https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg"
                }
                Title {
                    level 4
                    style [ style.paddingTop 20 ]
                    str "Fable.Builders.*"
                }
            }
             
            Space {
                style [ style.float'.right ]
                
                Html.div {
                    onClick (fun _ -> Browser.Dom.window.location.assign "https://github.com/uxsoft/Fable.Builders.Website" )
                    style [ style.textAlign.center; style.cursor.pointer ]
                    BasicIcon Icons.GithubFilled {
                        style
                            [ style.fontSize 24
                              style.marginRight 0
                              style.paddingTop 4 ]
                    }
                }
            }
            
        }
        Layout {
            Sider {
                style [
                    style.backgroundColor.white ]
                
                Menu {
                    selectedKeys [| string model.Page |]
                    MenuItemGroup {
                        label (str "General")
                        
                        PageMenuItem Page.SyntaxPage "Syntax"
                        PageMenuItem Page.ButtonPage "Button"
                        PageMenuItem Page.IconPage "Icon"
                        PageMenuItem Page.TypographyPage "Typography"
                    }
                    MenuItemGroup {
                        label (str "Layout")
                        
                        PageMenuItem Page.DividerPage "Divider"
                        PageMenuItem Page.GridPage  "Grid"
                        PageMenuItem Page.LayoutPage "Layout"
                    }
                    MenuItemGroup {
                        label (str "Navigation")
                        
                        PageMenuItem Page.MenuPage "Menu"
                        PageMenuItem Page.StepsPage "Steps"
                    }
                    MenuItemGroup {
                        label (str "Data Entry")
                        
                        PageMenuItem Page.FormPage "Form"
                        PageMenuItem Page.SelectPage "Select"
                    }
                    MenuItemGroup {
                        label (str "Data Display")
                        
                        PageMenuItem Page.ListPage "List"
                        PageMenuItem Page.CollapsePage "Collapse"
                        PageMenuItem Page.SegmentedPage "Segmented"
                        PageMenuItem Page.TablePage "Table"
                        PageMenuItem Page.TimelinePage "Timeline"
                    }
                    
                    MenuItemGroup {
                        label (str "Feedback")
                        PageMenuItem Page.NotificationPage "Notification"
                        PageMenuItem Page.ProgressPage "Progress"
                    }
                    
                    MenuItemGroup {
                        label (str "Charts")
                    
                        PageMenuItem Page.ChartsPage "Charts"
                    }
                    MenuItemGroup {
                        label (str "Drag & Drop")
                    
                        PageMenuItem Page.DnDKitPage "dnd-kit"
                        PageMenuItem Page.ReactBeautifulDnDPage "react-beautiful-dnd"

                    }
                    MenuItemGroup {
                        label (str "Others")
                        PageMenuItem Page.FelaPage "CSS-in-JS"
                        PageMenuItem Page.RouterPage "Routing"
                    }
                } 
            }
            Content {
                style [ style.padding(8) ]
                Outlet { () }
            }
        }
    }

let view (model: Model) dispatch =
    
    BrowserRouter {
        Routes {
            Route {
                path "/"
                element (App model dispatch)
                
                Route { path (string Page.SyntaxPage); element (SyntaxPage.view model) }
                Route { path (string Page.ButtonPage); element (ButtonPage.view model) }
                Route { path (string Page.IconPage); element (IconPage.view model) }
                Route { path (string Page.TypographyPage); element (TypographyPage.view model) }
                Route { path (string Page.DividerPage); element (DividerPage.view model) }
                Route { path (string Page.MenuPage); element (MenuPage.view model) }
                Route { path (string Page.GridPage); element (GridPage.view model) }
                Route { path (string Page.LayoutPage); element (LayoutPage.view model) }
                Route { path (string Page.StepsPage); element (StepsPage.view model) }
                Route { path (string Page.FormPage); element (FormPage.view model dispatch) }
                Route { path (string Page.SelectPage); element (SelectPage.view model) }
                Route { path (string Page.ListPage); element (ListPage.view model) }
                Route { path (string Page.CollapsePage); element (CollapsePage.view model) }
                Route { path (string Page.SegmentedPage); element (SegmentedPage.view model) }
                Route { path (string Page.TablePage); element (TablePage.view model) }
                Route { path (string Page.TimelinePage); element (TimelinePage.view model) }
                Route { path (string Page.NotificationPage); element (NotificationPage.view model) }
                Route { path (string Page.ProgressPage); element (ProgressPage.view model) }
                Route { path (string Page.ChartsPage); element (ChartsPage.view model) }
                Route { path (string Page.DnDKitPage); element (DnDKitPage.view model) }
                Route { path (string Page.ReactBeautifulDnDPage); element (ReactBeautifulDnDPage.View ()) }
                Route { path (string Page.FelaPage); element (FelaPage.view model) }
                Route {
                    path (string Page.RouterPage)
                    element (RouterPage.view model)
                    Route {
                        path ":paramName"
                    }
                }
                Route { path "*"; element notFound }
            }
        }
    }

// App
Program.mkProgram init update view
|> Program.withReactBatched "elmish-app"
|> Program.withConsoleTrace
|> Program.run
