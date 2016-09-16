var ResultWriter = function (output)
{
    if (!output)
    {
        throw "output not specified.";
    }
    this._output = output;  // we'll use the underscore convention for a member to be considered non-public
};

ResultWriter.prototype.writeResults = function writeResults(data)
{
    this.clear();
    if (!data)
    {
        return false;
    }
    for (var i = 0; i < data.length ; i++)
    {
        this._writeRow(data[i]);
    }
    return data.length > 0; // return whether any results were displayed
};

ResultWriter.prototype.clear = function clear()
{
    this._output.empty();
};

ResultWriter.prototype._writeRow = function _writeRow(row)
{
    this._startRow();
    this._onWriteRow(row);
    this._endRow();
};

ResultWriter.prototype._onWriteRow = function _onWriteRow(row)
{
    throw "_onWriteRow not implemented.";
};

ResultWriter.prototype._startRow = function _startRow()
{
    this._output.append("<tr>");
};

ResultWriter.prototype._endRow = function _endRow()
{
    this._output.append("</tr>");
};

ResultWriter.prototype._writeValue = function _writeValue(value)
{
    this._output.append("<td>" + value + "</td>");
};

ResultWriter.prototype._writeImage = function _writeImage(imageURL)
{
    this._output.append("<td><img src='" + imageURL + "'/></td>");
};

var PeopleResultWriter = function (output)
{
    ResultWriter.call(this, output);
}

PeopleResultWriter.prototype = Object.create(ResultWriter.prototype);

PeopleResultWriter.prototype._onWriteRow = function _onWriteRow(person)
{
    if (person)
    {
        this._writeValue(person.Name);
        this._writeValue(person.Address);
        this._writeValue(person.Age);
        this._writeValue(person.Interests);
        this._writeImage(person.ImageURL);
    }
};