using HiddenLibrary;

public class A { }

public class B : A { }

[Hidden]
public class C : A { }

public class D : B { }
