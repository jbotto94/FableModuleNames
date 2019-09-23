#nowarn "77"
// Warn FS0077 -> Member constraints with the name 'get_Item' are given special status by the F# compiler as certain .NET types are implicitly augmented with this member. This may result in runtime failures if you attempt to invoke the member constraint from your own code.
// Those .NET types are string and array. String is explicitely handled here and array through the seq overload.

namespace FSharpPlus.Internals



type ToSeq =
    inherit Default1
    static member inline Invoke (source: '``Foldable<'T>``) : seq<'T>  =
        let inline call_2 (a: ^a, b: ^b) = ((^a or ^b) : (static member ToSeq : _*_ -> _) b, a)
        let inline call (a: 'a, b: 'b) = call_2 (a, b)
        call (Unchecked.defaultof<ToSeq>, source)

