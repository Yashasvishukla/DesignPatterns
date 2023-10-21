**Intent**:
1.  Adapter is a structual design pattern that allows objects with incompatible interfaces to collabrate.
2.  This is a specical object that converts the interface of one object so that other object can understand it.
3.  An adapter wraps one of the objects to hide the complexity of coversion happening behind the scenes. The wrapped object isn't even aware of the adapter.

**Advantages**:
1. The adapter gets an interface, compatible with one of the exisiting objects
2. Using this interface, the existing object can safely call the adapter's method
3. Upon receiving a call, the adapter passes the request to the second object, but in a format and order that the second object expects.

![image](https://github.com/Yashasvishukla/DesignPatterns/assets/35268031/074f1357-c695-46a1-9f53-50d74c51bf17)





**Structure**:

1. **Object adapter**
**- This implementation uses the object composition priniciple. The adapter implements the interface of one object and wraps the other one.**

![image](https://github.com/Yashasvishukla/DesignPatterns/assets/35268031/ee91ff13-325a-4a92-8024-212939f49e79)

2. **Class Adapter**
     **- This implementation uses inheritance: the adapter inherits interface from both objects at the same time.**

![image](https://github.com/Yashasvishukla/DesignPatterns/assets/35268031/05141f39-e404-48f3-8112-7cdc9b75e420)


Real-world scenario

A real-world scenario where the Adapter pattern is used is in the area of payment processing. Different payment processors have different APIs. This can make it difficult for a merchant to accept payments from multiple processors.

To solve this problem, a merchant can use a payment gateway. A payment gateway is a service that acts as an adapter between the merchant's website and the different payment processors. The merchant simply needs to integrate with the payment gateway's API. The payment gateway will then take care of translating the merchant's requests into the appropriate format for each payment processor.

Benefits of the Adapter pattern

The Adapter pattern offers a number of benefits, including:

Increased flexibility: The Adapter pattern allows classes with incompatible interfaces to work together. This can make it easier to reuse existing code and to integrate third-party libraries into a codebase.
Reduced coupling: The Adapter pattern helps to decouple classes from each other. This makes it easier to change or replace classes without affecting other classes in the system.
Increased maintainability: The Adapter pattern can make code more maintainable by encapsulating the details of incompatible interfaces. This can make it easier to understand and modify the code.
