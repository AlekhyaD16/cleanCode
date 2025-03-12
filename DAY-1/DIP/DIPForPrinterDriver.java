public class PrinterDriver
{
    private IInput input;
    private Printer printer;

    public PrinterDriver(IInput input, Printer printer){
        this.input = input;
        this.printer = printer;
    }

    public void Print(){
        buffer page = this.input.getNextPage();
        while(!this.input.IsEndOfFile(page)){
            this.printer.Print(page);
            page = this.input.getNextPage();
        }
    }
}

public interface IInput{
    bool IsEndOfFile();
    buffer getNextPage();
}

public class PDFFile(): IInput{
    bool IsEndOfFile() {}
    buffer getNextPage() {}
}

public class myScanner(): IInput{
    bool IsEndOfFile() {}
    buffer getNextPage() {}
}

public class myMobile(): IInput{
    bool IsEndOfFile() {}
    buffer getNextPage() {}
}
