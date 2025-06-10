using HiddenLibrary;

namespace Test
{
    public class A { }

    public class B : A { }

    [Hidden]
    public class C : A { }

    public class D : B { }

    public class E : A { }

    public class F : C { }
}
