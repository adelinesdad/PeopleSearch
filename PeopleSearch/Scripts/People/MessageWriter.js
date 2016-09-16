var MessageWriter = function (messageElmt)
{
    if (!messageElmt)
    {
        throw "message element not specified.";
    }
    this._messageElmt = messageElmt;
};

MessageWriter.prototype.messages =
{
    enterSearchTerm: "Please enter a search term.",
    searching: "Searching...",
    noResults: "No results found.",
    error: "An error occurred"
};

MessageWriter.prototype.clear = function clear()
{
    this._messageElmt.addClass("hidden");
    this._messageElmt.html("");
};

MessageWriter.prototype.show = function show(message)
{
    this._messageElmt.removeClass("hidden");
    this._messageElmt.html(message);
};