namespace FSharpPlus.Control

open System
open System.Text
open System.Runtime.CompilerServices
open System.Collections
open System.Collections.Generic
open System.Runtime.InteropServices
open FSharpPlus
open FSharpPlus.Internals


type OfSeq =
    inherit Default1
    static member inline Invoke (value: seq<'t>) = 
        let inline call_2 (a: ^a, b: ^b, s) = ((^a or ^b) : (static member OfSeq : _*_*_ -> _) s, b, a)
        let inline call (a: 'a, s) = call_2 (a, Unchecked.defaultof<'r>, s) : 'r
        call (Unchecked.defaultof<OfSeq>, value)



type Distinct =
    inherit Default1

    static member        Distinct (x: list<'a>, [<Optional>]_impl: Distinct) = List.distinct x
    static member        Distinct (x: 'a []   , [<Optional>]_impl: Distinct) = Array.distinct x
    static member inline Distinct (x: '``Collection<'T>``  , [<Optional>]_impl: Default2) = x |> ToSeq.Invoke |> Seq.distinct |> OfSeq.Invoke         : '``Collection<'T>``
    static member inline Distinct (x: ^``Collection<'T>``  , [<Optional>]_impl: Default1) = (^``Collection<'T>`` : (static member Distinct : _->_) x) : '``Collection<'T>``
    static member inline Distinct (_: ^t when ^t : null and ^t : struct, _mthd: Default1) = id
