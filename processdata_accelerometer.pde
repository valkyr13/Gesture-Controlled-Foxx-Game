
import processing.serial.*;    // Importing the serial library to communicate with the Arduino 
Serial myPort;
String v;
//String myp;
PrintWriter output;
void setup() {
   size(200,200);
   //myp = Serial.list()[3];
   myPort  =  new Serial (this, "COM5",  9600);
   myPort.clear();
   myPort.bufferUntil('\n');
   v = myPort.readStringUntil('\n');
   output = createWriter( "C:\\Users\\Public\\Documents\\Unity Projects\\Foxx\\Assets\\data.txt");
}
void draw() {
  if (myPort.available() > 0){
    v = myPort.readStringUntil('\n');
    int val = Integer.parseInt(v.trim());
    if (v!=null){
       println(v);
       //println(val);
       //int val = int(v);
       //println("helloworld");
       //println(val);
       output.println(val);
       output.flush();
    }
   
  }
   
}

void keyPressed() { 
    output.close();  // Finishes the file
    exit();  // Stops the program
}
