# GenericDeepEquality
Have a project with a lot of objects? Want to test equality, like for tests, without a lot of code?

First, if one or the other is null, it is equal if both are null.

Then they are not equal if they are not the same type.

If a class implements IEquatable, then it knows if it is equal.

Then determines if the class is an Enumerable. For Enumerables ensures each item in both lists is in the other list. Then and compares counts to limit issues with duplicates.

Otherwise, reflection is used to get each property and field and compares them.

If a class contains a property or field of it's own type, assumes it is a reference to itself and skips.

All comparisons are done recursively using GenericDeepEqualityComparer Equal function.

Known limitations - 
    If both values are null, will return equal, even if original nullable types where different. This is a limitation of the language/ .Net.
    If both Enumerables contain duplicates, and both Enumerables contain the same number of elements, will return true, even if duplicate are different between lists
      (1,2,2,3) equals (1,2,3,3).
