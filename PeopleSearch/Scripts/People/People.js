/// <reference path="Search.js" />
/// <reference path="ResultWriter.js" />
/// <reference path="MessageWriter.js" />

$(document).ready(function ()
{
    var resultWriter = new PeopleResultWriter($("#searchResult"));
    var messageWriter = new MessageWriter($("#message"));
    var search = new Search(resultWriter, messageWriter);

    messageWriter.show(messageWriter.messages.enterSearchTerm);

    $("#searchForm").submit(function (event)
    {
        var searchString = $("#searchString").val();
        var simulateDelay = $("#simulateDelay")[0].checked;
        search.beginSearch(searchString, simulateDelay);
        return false;   // cancel form submit
    });
});