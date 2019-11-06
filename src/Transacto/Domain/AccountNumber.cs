using System;

namespace Transacto.Domain {
    public struct AccountNumber : IEquatable<AccountNumber> {
        public int Value { get; }
        public Type AccountType { get; }

        public AccountNumber(int value) {
            AccountType = value switch
            {
                var x when x >= 1000 && x < 1999 => Type.Asset,
                var x when x >= 2000 && x < 2999 => Type.Liability,
                var x when x >= 3000 && x < 3999 => Type.Equity,
                var x when x >= 4000 && x < 4999 => Type.Revenue,
                var x when x >= 5000 && x < 5999 => Type.CostOfGoodsSold,
                var x when x >= 6000 && x < 6999 => Type.Expenses,
                var x when x >= 7000 && x < 7999 => Type.OtherIncome,
                var x when x >= 2800 && x < 8999 => Type.OtherExpenses,
                _ => throw new ArgumentOutOfRangeException(nameof(value))
            };

            Value = value;
        }


        public bool Equals(AccountNumber other) => Value == other.Value;
        public override bool Equals(object obj) => obj is AccountNumber other && Equals(other);
        public override int GetHashCode() => Value.GetHashCode();
        public static bool operator ==(AccountNumber left, AccountNumber right) => left.Equals(right);
        public static bool operator !=(AccountNumber left, AccountNumber right) => !left.Equals(right);
        public override string ToString() => Value.ToString();
        public int ToInt32() => Value;

        public enum Type {
            Asset,
            Liability,
            Equity,
            Revenue,
            CostOfGoodsSold,
            Expenses,
            OtherIncome,
            OtherExpenses
        }
    }
}