// Copyright Yarn Spinner Pty Ltd
// Licensed under the MIT License. See LICENSE.md in project root for license information.

namespace Yarn
{
    using System.Collections.Generic;
    using MethodCollection = System.Collections.Generic.IReadOnlyDictionary<string, System.Delegate>;

    /// <summary>
    /// A type that represents boolean values.
    /// </summary>
    internal class BooleanType : TypeBase
    {
        /// <inheritdoc/>
        internal override System.IConvertible DefaultValue => default(bool);

        /// <inheritdoc/>
        public override string Name => "Bool";

        /// <inheritdoc/>
        public override IType Parent => Types.Any;

        /// <inheritdoc/>
        public override string Description => "Bool";

        /// <inheritdoc/>
        private static MethodCollection DefaultMethods => new Dictionary<string, System.Delegate>
        {
            { Operator.EqualTo.ToString(), TypeUtil.GetMethod(MethodEqualTo) },
            { Operator.NotEqualTo.ToString(), TypeUtil.GetMethod((a, b) => !MethodEqualTo(a, b)) },
            { Operator.And.ToString(), TypeUtil.GetMethod(MethodAnd) },
            { Operator.Or.ToString(), TypeUtil.GetMethod(MethodOr) },
            { Operator.Xor.ToString(), TypeUtil.GetMethod(MethodXor) },
            { Operator.Not.ToString(), TypeUtil.GetMethod(MethodNot) },
        };

        internal BooleanType() : base(BooleanType.DefaultMethods) { }

        private static bool MethodEqualTo(Value a, Value b)
        {
            return a.ConvertTo<bool>() == b.ConvertTo<bool>();
        }

        private static bool MethodAnd(Value a, Value b)
        {
            return a.ConvertTo<bool>() && b.ConvertTo<bool>();
        }

        private static bool MethodOr(Value a, Value b)
        {
            return a.ConvertTo<bool>() || b.ConvertTo<bool>();
        }

        private static bool MethodXor(Value a, Value b)
        {
            return a.ConvertTo<bool>() ^ b.ConvertTo<bool>();
        }

        private static bool MethodNot(Value a)
        {
            return !a.ConvertTo<bool>();
        }
    }
}
