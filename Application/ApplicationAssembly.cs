using System.Reflection;

namespace Application;

public class ApplicationAssembly{
    public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}