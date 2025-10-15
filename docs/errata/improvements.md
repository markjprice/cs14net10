**Improvements** (1 item)

If you have suggestions for improvements, then please [raise an issue in this repository](https://github.com/markjprice/cs14net10/issues) or email me at markjprice (at) gmail.com.

# Page 267 - Controlling how parameters are passed

> Thanks to [alhi44](https://github.com/alhi44) who raised an [issue on September 14, 2025](https://github.com/markjprice/cs13net9/issues/78) that prompted this improvement.

It is too late for the 10th edition in 2025, but in the 11th edition I will add an analogy about passing pieces of paper, as follows: 

When a parameter is passed into a method, it can be passed in one of several ways:

1. By **value** (this is the default): Think of these as being *in-only*. Although the value can be changed, this only affects the parameter in the method. Imagine someone has a piece of paper with a number written on it. They pass a photocopy of the paper, not the original. The function can write on the photocopy, but the original remains unchanged.
2. As an `out` parameter: Think of these as being *out-only*. `out` parameters cannot have a default value assigned in their declaration and cannot be left uninitialized. They must be set inside the method; otherwise, the compiler will give an error. Imagine someone has a blank piece of paper and asks the function to write on it. They cannot pass an empty piece of paper; it *must* be blank. And the function *must* write on it before returning it.
3. By reference as a `ref` parameter: Think of these as being *in-and-out*. Like `out` parameters, `ref` parameters also cannot have default values, but since they can already be set outside the method, they do not need to be set inside the method. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to write on it. This means that any changes made are immediately visible to them as well as you. The paper *must* have a number written on it before it is passed.
4. As an `in` parameter: Think of these as being a reference parameter that is read-only. `in` parameters cannot have their values changed and the compiler will show an error if you try. Imagine someone has a piece of paper with a number written on it. They pass the original piece of paper and allow the function to read it but not write on it.
