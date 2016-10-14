# XML Basics

1. What does the XML language represent? What is it used for?
	-  XML (Extensible Markup Language) е подобен език като HTML,
	в който има отварящи и затварящи тагове - етикети.
	- Таговете (етикетите) не са строго дефинирани и при нужда се създава собствен таг.
	- Има дървовидна структура.
	- Всеки XML	документ започва с етикет `<?xml version="1.0"?>`. Ако този етикет
	липсва XML документът не е валиден.
	- Използва се за обмен на данни между различни програми, като използва общ стандарт.


3. What do namespaces represent in an XML document? What are they used for?
 - В XML имената на етикетите се създават от програмиста. Това доста често води до конфликт
 при опит да се обединят два или повече XML документа.
 - Благодарение на namespaces този проблем се решава, след като се сложи `name prefix` за всеки документ.
 - Namespace се дефинира с `xmlns` атрибут в първия таг на елемента.
 - Синтакс `xmlns:prefix="URI"`

```xml
Пример 1

<root>

<h:table xmlns:h="http://www.w3.org/TR/html4/">
	<h:tr>
	<h:td>Apples</h:td>
	<h:td>Bananas</h:td>
	</h:tr>
</h:table>

<f:table xmlns:f="http://www.w3schools.com/furniture">
	<f:name>African Coffee Table</f:name>
	<f:width>80</f:width>
	<f:length>120</f:length>
</f:table>

</root>
```

```xml
Пример 2

<root
xmlns:h="http://www.w3.org/TR/html4/"
xmlns:f="http://www.w3schools.com/furniture">

<h:table>
	<h:tr>
	<h:td>Apples</h:td>
	<h:td>Bananas</h:td>
	</h:tr>
</h:table>

<f:table>
	<f:name>African Coffee Table</f:name>
	<f:width>80</f:width>
	<f:length>120</f:length>
</f:table>

</root>
```


4. Learn more about URI, URN and URL definitions.
 - URI не се използват при преглеждането на иформацията от XML документа.
 - URI позволява използване на уникални имена.
 - Много често при създаване на URI се слага namespace, който води към уеб страница,
 която дава повече информация за самия namespace.

[Good read](https://stackoverflow.com/questions/12818957/namespace-prefix-for-childelements-in-xml-schema)