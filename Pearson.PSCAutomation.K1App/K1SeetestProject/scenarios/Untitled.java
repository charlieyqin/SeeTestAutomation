//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
*/
public class Untitled {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "D:\\Branch-Code\\SeeTestAutomation\\Pearson.PSCAutomation.K1App\\K1SeetestProject";
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
        // Generates a report of the test case.
        // For more information - http://experitest.com/studio/help2/WebHelp/help.htm#Report_Of_Executed_Script.htm .
        client.generateReport(false);
        // Releases the client so that other clients can approach the agent in the near future. 
        client.releaseClient();
    }
}
