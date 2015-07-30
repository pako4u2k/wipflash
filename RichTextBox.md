# Introduction #

RichTextBox is more than just a formatted text box. It now provides ways of formatting paragraphs either inline or in blocks, together with any other UI elements you care to add. As a result, setting text in or getting text from a RichTextBox can be tricky. Here's how we do it.

# Details #

We set text in a RichTextBox by selecting all the text in it, then hitting keystrokes to replace that text. It's cludgy and it doesn't follow the pattern in the rest of the UI framework. It will also grab focus.

Knowing what text is inside a RichTextBox is also tricky. A RichTextBox has a document, inside which may be other AutomationElements which may have their own documents.

So, to get the text, WiPFlash grabs the text from the RichTextBox itself, then looks for any children and gets the text from them. It supports child elements which support TextPattern or  ValuePattern, or which are Labels or TextBlocks. When a child element supports TextPattern, WiPFlash recurses the process with _its_ children too.