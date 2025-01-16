using System;

public class Entry {
    public string Prompt {get; set;}
    public string Response { get; set;}
    public DateTime DateTime { get; set;}

    public Entry(string prompt, string response, DateTime dateTime)
    {
        Prompt = prompt;
        Response = response;
        DateTime = dateTime;
    }

}