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


type TestType =
    static member TestType (x: list<'a>) = x
    static member TestType (x: 'a []) = x


type TestType1 =
    static member inline TestType1 (x: list<'a>) = x
    static member inline TestType1 (x: 'a []) = x


type TestType2 =
    static member inline TestType2 (x: list<'a>) = x
    static member TestType2 (x: 'a []) = x



type Distinct1 =
//    static member        Distinct1 (x: list<'a>, [<Optional>]_impl: Distinct1) = List.distinct x
    static member inline Distinct1 (x: ^``Collection<'T>``  , [<Optional>]_impl: Default1) = (^``Collection<'T>`` : (static member Distinct1 : _->_) x) : '``Collection<'T>``
    static member inline Distinct1 (_: ^t when ^t : null and ^t : struct, _mthd: Default1) = id //must



type Distinct =
    inherit Default1

    static member        Distinct (x: list<'a>, [<Optional>]_impl: Distinct) = List.distinct x
    static member        Distinct (x: 'a []   , [<Optional>]_impl: Distinct) = Array.distinct x
    static member inline Distinct (x: '``Collection<'T>``  , [<Optional>]_impl: Default2) = x |> ToSeq.Invoke |> Seq.distinct |> OfSeq.Invoke         : '``Collection<'T>``
    static member inline Distinct (x: ^``Collection<'T>``  , [<Optional>]_impl: Default1) = (^``Collection<'T>`` : (static member Distinct : _->_) x) : '``Collection<'T>``
    static member inline Distinct (_: ^t when ^t : null and ^t : struct, _mthd: Default1) = id


type Rev =
    inherit Default1

    static member        Rev (x: list<'a>   , [<Optional>]_impl: Rev  ) = List.rev x
    static member        Rev (x: 'a []      , [<Optional>]_impl: Rev  ) = Array.rev x
    static member inline Rev (x: '``Collection<'T>``, [<Optional>]_impl: Default2) = x |> ToSeq.Invoke |> Seq.rev |> OfSeq.Invoke         : '``Collection<'T>``
    static member inline Rev (x: ^``Collection<'T>``, [<Optional>]_impl: Default1) = (^``Collection<'T>`` : (static member Rev : _->_) x) : '``Collection<'T>``
    static member inline Rev (_: ^t when ^t: null and ^t: struct, _mthd: Default1) = id

type Sort =
    inherit Default1

    static member        Sort (x: list<'a>, [<Optional>]_impl: Sort) = List.sort x
    static member        Sort (x: 'a []   , [<Optional>]_impl: Sort) = Array.sort x
    static member inline Sort (x: '``Collection<'T>``, [<Optional>]_impl: Default2) = x |> ToSeq.Invoke |> Seq.sort |> OfSeq.Invoke         : '``Collection<'T>``
    static member inline Sort (x: ^``Collection<'T>``, [<Optional>]_impl: Default1) = (^``Collection<'T>`` : (static member Sort : _->_) x) : '``Collection<'T>``
    static member inline Sort (_: ^t when ^t: null and ^t: struct, _mthd: Default1) = id

type Split =
    inherit Default1
    
    static member Split ((e: list<string>      , x: string       ), [<Optional>]_impl: Split) = x.Split (Seq.toArray e, StringSplitOptions.None) |> Array.toList
    static member Split ((e: seq<StringBuilder>, x: StringBuilder), [<Optional>]_impl: Split) = x.ToString().Split (e |> Seq.map string |> Seq.toArray, StringSplitOptions.None) |> Array.map StringBuilder :> seq<_>
    static member Split ((e: StringBuilder []  , x: StringBuilder), [<Optional>]_impl: Split) = x.ToString().Split (e |> Seq.map string |> Seq.toArray, StringSplitOptions.None) |> Array.map StringBuilder
    static member Split ((e: StringBuilder list, x: StringBuilder), [<Optional>]_impl: Split) = x.ToString().Split (e |> Seq.map string |> Seq.toArray, StringSplitOptions.None) |> Array.map StringBuilder |> Array.toList

 type Split with
    static member inline Split ((e: '``'Collection<'OrderedCollection>``, x: '``'OrderedCollection``), [<Optional>]_impl: Default1) = (^``'OrderedCollection`` : (static member Split : _*_->_) e, x)                          : '``'Collection<'OrderedCollection>``
    static member inline Split ((_: ^t when ^t: null and ^t: struct, _                              ),             _mthd: Default1) = id

