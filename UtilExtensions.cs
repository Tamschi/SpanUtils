using System;
using System.Runtime.InteropServices;

namespace SpanUtils
{
    public static class UtilExtensions
    {
        public static ref T View<T>(this Span<byte> @this, int offset) where T : unmanaged => ref MemoryMarshal.Cast<byte, T>(@this.Slice(offset, Marshal.SizeOf<T>()))[0];
        public static Span<T> ViewRange<T>(this Span<byte> @this, int offset, int count) where T : unmanaged => MemoryMarshal.Cast<byte, T>(@this.Slice(offset, Marshal.SizeOf<T>() * count));
        public static Span<R> Cast<R>(this Span<byte> @this) where R : unmanaged => MemoryMarshal.Cast<byte, R>(@this);
    }
}
