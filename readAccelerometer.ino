
int zpin = A2;
int ypin = A1;
int xpin = A0;
// These are only used if you're plugging the ADXL335 (on the
// Adafruit breakout board) directly into the analog input pins
// of your Arduino. See comment below.
int vinpin = A5;
int voutpin = A4;
int gndpin = A3;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  // Uncomment the following lines if you're using an ADXL335 on an
  // Adafruit breakout board (https://www.adafruit.com/products/163)
  // and want to plug it directly into (and power it from) the analog
  // input pins of your Arduino board.
//  pinMode(vinpin, OUTPUT); digitalWrite(vinpin, HIGH);
//  pinMode(gndpin, OUTPUT); digitalWrite(gndpin, LOW);
//  pinMode(voutpin, INPUT);
  
  pinMode(xpin, INPUT);
  pinMode(ypin, INPUT);
  pinMode(zpin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  //Serial.print(analogRead(xpin)); Serial.print("\t");
  //Serial.print(analogRead(ypin)); Serial.print("\t");
  //Serial.print(analogRead(zpin)); Serial.println();
  // int x = analogRead(xpin);
  int y = analogRead(ypin);
  int z = analogRead(zpin);
  delay(1500);
  //Serial.print(analogRead(xpin)); Serial.print("\t");
  //Serial.print(analogRead(ypin)); Serial.print("\t");
  //Serial.print(analogRead(zpin)); Serial.println();
  // int x1 = analogRead(xpin);
  int y1 = analogRead(ypin);
  int z1 = analogRead(zpin);
  int zdelta = z1-z;
  int ydelta = y1-y;
  int x = 0;
  if(x%2==0){
      Serial.println(zdelta);
    }
    else{
      Serial.println(ydelta); 
    }
    x = x +1;
    delay(1000);

  
}
