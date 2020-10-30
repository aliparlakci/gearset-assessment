## Usage

```bash
dotnet restore
cd GearsetAssessment
dotnet run -- input.txt
```

Output pdf file will be `GearsetAssessment/output.pdf`

## Run Tests

```bash
dotnet restore
dotnet test
```

## My views on the final version of the project

- In the sample input, it was not clear when to create a new paragraph. I assumed that both _.paragraph_ and _.indent_ commands go onto a new paragraph. Also I did not create a new paragraph on *.large* or *.normal* commands.
- Commands list did not contained definion on *.large* and *.normal* commands but they were present on the sample. Thus, I implemented them also. 
- I was not sure where to put the _ExtractMethod_ function. I decided best place would be a separate static class. However, I am still uncomfortable because of the way if clauses are stacked. Currently, it is the only solution I can think of.
- At first, I did not want to create an interface for PdfBuilder but for unit tests of _CommandParser_, Moq required some kind of abstraction. Otherwise, it cannot add spies on the methods of the mocked class.
