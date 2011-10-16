# TemplatesProgressiveEnhancement

JQuery templates rendering for progressive enhancement in ASP.NET MVC

A small library whose sole aim is to render a partial view containing a jquery template 
only, so that the template keys (like ${Name}) will be replaced with the value of the respectively
named property of the view model. This is done in order to enable progressive enhancement - 
namely accessibility - for your ASP.NET MVC 3 application.

For more info see http://nieve.heroku.com/post/Progressive_enhancement_for_JQuery_templates_with_MVC

## Using it
To start rendering your jquery templates, reference the TemplatesProgressiveEnhancement dll 
and in your global asax add:

````
this.ConfigureTemplateRendering().WithDefaults(); //uses Views/Templates
````

or:

````
this.ConfigureTemplateRendering().WithPath("your/own/templates/path");
````

Then in your controller you can call 

````
this.Template("SomeTemplate", viewModel);
````

Which can take either a view model or an array of them. 
This will get you a ContentResult with the template html, replacing all keys with properties values.


# Legal Mumbo Jumbo (MIT License)

Copyright (c) 2011 Nieve Goor

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.