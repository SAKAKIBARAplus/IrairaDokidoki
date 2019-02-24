const int AVERAGE = 100;
const int LED = 9;
const int XIN = 1;
const int YIN = 2;
const int BUTTON = 7;
//int val = 0;
int button = 0;
long val[AVERAGE]={};
long valsum = 0;
long xinput = 0;
long yinput = 0;
double valave = 0;
int count = 0;
//int state = 0;
//int LEDstate = 0;

long YMAX = 500;
long ZMAX = 500;
long YMIN = 500;
long ZMIN = 500;

void setup(){
  pinMode(LED,OUTPUT);    //13Pinを出力にする
  Serial.begin(9800);     //モニター出力
  pinMode(BUTTON,INPUT);  //7Pinを入力にする
}
void loop(){
//  digitalWrite(LED,HIGH);
//  delay(1000);
//  digitalWrite(LED,LOW);
//  delay(1000);
   
    button = digitalRead(BUTTON);
    xinput = 0;
    yinput = 0;
    valsum = 0;
    
    for(int x = 0;x<AVERAGE;x++)
    {
      //if(analogRead(0) >= 400){
          valsum += analogRead(0);
      //}
      xinput += analogRead(XIN);
      yinput += analogRead(YIN);
    }
    
    analogWrite(LED,valave/4);
    delay(10);

    xinput = xinput/AVERAGE;
    yinput = yinput/AVERAGE;
    valave = valsum/AVERAGE;
    
    Serial.print(valave/4);
    Serial.print(",");
    Serial.print(xinput);
    Serial.print(",");
    Serial.print(yinput);
    Serial.print(",");
    Serial.println(button);
//    if( == HIGH){
//      digitalWrite(LED,HIGH);
//      delay(val);
//    }else{
//      digitalWrite(LED,LOW);
//      delay(val);
//    }
}
