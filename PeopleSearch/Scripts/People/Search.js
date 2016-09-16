var Search = function (resultWriter, messageWriter)
{
    this._resultWriter = resultWriter;
    this._messageWriter = messageWriter;
    this._messages = this._messageWriter.messages;
    this._currentRequest = null;
};

Search.prototype.beginSearch = function beginSearch(searchString, simulateDelay)
{
    searchString = this._validateAndFormat(searchString);
    simulateDelay = !!simulateDelay;    // ensure bool
    if (!searchString)
    {
        this._messageWriter.show(this._messages.enterSearchTerm);
        this._resultWriter.clear();
        this._abortCurrentRequest();
    }
    else
    {
        this._messageWriter.show(this._messages.searching);
        this._executeRequest(searchString, simulateDelay);
    }
};

Search.prototype._validateAndFormat = function _validateAndFormat(searchString)
{
    if (!searchString)
    {
        return null;    // null = invalid
    }
    searchString = searchString.trim();
    return searchString || null;
};

Search.prototype._executeRequest = function _executeRequest(searchString, simulateDelay)
{
    var request = $.ajax("/People/Search/",
        {
            type: "POST",
            data: JSON.stringify(
                {
                    searchString: searchString,
                    simulateDelay: simulateDelay
                }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: $.proxy(this._processResult, this),
            error: $.proxy(this._handleError, this)
        });
    this._setCurrentRequest(request);
};

Search.prototype._processResult = function _processResult(data, successCode, request)
{
    if (this._checkCurrentRequest(request))
    {
        if (this._resultWriter.writeResults(data))
        {
            this._messageWriter.clear();
        }
        else
        {
            // no results were displayed
            this._messageWriter.show(this._messages.noResults);
        }
    }
};

Search.prototype._handleError = function _handleError(request, errorType, errorMessage)
{
    if (this._checkCurrentRequest(request))
    {
        this._resultWriter.clear();
        var message = this._formatError(errorMessage);
        this._messageWriter.show(message);
    }
};

Search.prototype._abortCurrentRequest = function _abortCurrentRequest()
{
    this._setCurrentRequest(null);
};

Search.prototype._setCurrentRequest = function _setCurrentRequest(request)
{
    var oldRequest = this._currentRequest;
    this._currentRequest = request;
    if (oldRequest)
    {
        oldRequest.abort();
    }
};

Search.prototype._checkCurrentRequest = function _checkCurrentRequest(request)
{
    if (this._currentRequest !== request)
    {
        return false;
    }
    this._currentRequest = null;
    return true;
};

Search.prototype._formatError = function _formatError(errorMessage)
{
    var message = this._messages.error;
    if (errorMessage)
    {
        message += ": " + errorMessage;
    }
    return message;
};