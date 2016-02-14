//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
 *
*/
public class Untitled {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "D:\\Def File\\akanksha\\SeeTestAutomation\\Pearson.PSCAutomation.212App\\212SeeTestProject\\default";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "Untitled");
    }

    @Test
    public void testUntitled(){
        // it is recommended to start your script with SetDevice command:
        // client.setDevice( <Device Name>);
    }

    @After
    public void tearDown(){
        client.generateReport(true);
    }
}
