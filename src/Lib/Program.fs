namespace FSharpx.Collections

open System
open System.Collections
open System.Collections.Generic

/// An ArraySegment with structural comparison and equality.
type ByteString() =

    /// Gets an enumerator for the bytes stored in the byte string.
    member x.GetEnumerator() =
        { new IEnumerator<_> with
            member self.Current = invalidOp "!"
          interface System.Collections.IEnumerator with
            member self.Current = invalidOp "!"
            member self.MoveNext() = false
            member self.Reset() = ()
          interface System.IDisposable with
            member self.Dispose() = () }

    interface IEnumerable<byte> with
        /// Gets an enumerator for the bytes stored in the byte string.
        member this.GetEnumerator() = this.GetEnumerator()

    interface IEnumerable with
        /// Gets an enumerator for the bytes stored in the byte string.
        member this.GetEnumerator() = this.GetEnumerator() :> IEnumerator
