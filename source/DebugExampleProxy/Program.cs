using System;

namespace DebugExampleProxy
{
    using Castle.DynamicProxy;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            var generator = new ProxyGenerator();

            var proxy = generator.CreateInterfaceProxyWithTarget<IFoo>(new Target(),new Interceptor());

            /* 1: */ proxy.Method();

        }
    }

    class Interceptor : IInterceptor

    {

        public void Intercept(IInvocation invocation)

            /* 2: */
        {
            Console.WriteLine("In interceptor");
            /* 3: */
            invocation.Proceed();

        }

    }

    public interface IFoo
    {
        void Method();
    }
    class Target : IFoo

    {

        public void Method()

            /* 4: */
        {
            Console.WriteLine("In target");
        }

    }

}
