open System  
open System.Windows.Forms


type RandomTicker(approxInterval) =    
    let timer = new Timer()    
    let rnd = new System.Random(99)    
    let tickEvent = new Event<int> ()

    let chooseInterval() : int = 
        approxInterval + approxInterval / 4 - rnd.Next(approxInterval / 2) 
    
    do timer.Interval <- chooseInterval() 

    do timer.Tick.Add(fun args ->  
        let interval = chooseInterval() 
        tickEvent.Trigger interval; 
        timer.Interval <- interval) 

    member x.RandomTick = tickEvent.Publish 
    member x.Start() = timer.Start() 
    member x.Stop() = timer.Stop() 
    interface IDisposable with member x.Dispose() = timer.Dispose()

let rt = new RandomTicker(1000);;
rt.RandomTick.Add(fun nextInterval -> printfn "Tick, next = %A" nextInterval);;
rt.Start() 
rt.Stop()

let xs = [1..10]
xs
|> List.filter (fun x -> x % 2 = 0)
|> List.map (fun x -> x * 2)

let filterMap f m = (List.filter f >> List.map m)
xs 
|> filterMap (fun x -> x % 2 = 0) (fun x -> x * 2)

xs
|> List.choose (fun x -> 
                match x with 
                | x when x % 2 = 0 -> Some (x * 2)
                | _ -> None )


xs
|> List.choose (function  
                | x when x % 2 = 0 -> Some (x * 2)
                | _ -> None )

System.IntPtr.Size // to check for 32-bit / 64-bit


// Check Option.map

let xs1 = [Some(3);None;Some(5);None;Some(10)]

let xs2 = Option.map (fun x -> x * 2) 

xs1 |> List.map (Option.map (fun x -> x *2)) |> ignore


let xs = [1; 2; 3; 4; 5]
xs |> List.collect (fun x -> List.replicate 3 x)

let repCol n x   =  (List.replicate n x)  << List.collect  

let repCol (xs:list<'T>) = (List.replicate 3 xs) << List.collect


let repCol n xs = (List.replicate n ) << List.collect xs 

let repCol n xs = (List.replicate >> List.collect) n xs

repCol 4 xs

[<Literal>] let X = __SOURCE_DIRECTORY__ + @"\blah"



open FSharp.Linq.NullableOperators


let x = System.Nullable<float> 4.
let y = x ?* 3.0

System.Nullable(0.)
System.Nullable 0.

Option.ofNullable(y)

float y

open System.Collections.Generic
let xs = ResizeArray [1;2;3]
xs.RemoveAt(2)

xs