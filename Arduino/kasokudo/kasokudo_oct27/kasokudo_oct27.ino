const int AVERAGE = 100;
const int LED = 9;
const int XIN = 1;
const int YIN = 2;
const int YACC = 3;
const int ZACC = 4;
const int BUTTON = 7;

//int val = 0;
int button = 0;
long val[AVERAGE]={};
long valsum = 0;
long xinput = 0;
long yinput = 0;
long Yacc = 0;
long Zacc = 0;

long YMAX = 500;
long ZMAX = 500;
long YMIN = 500;
long ZMIN = 500;

double valave = 0;
int count = 0;
//int state = 0;
//int LEDstate = 0;

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

      valsum = 0;
      Yacc = 0.0;
      Zacc = 0.0;
    
//    valsum = valsum - val[count];
//    val[count] = analogRead(0);
//    if(val[count] <= 400){
//      val[count] = 0;
//    }
//    valsum = valsum + val[count];
//    valave = valsum / AVERAGE;

    for(int x = 0;x<AVERAGE;x++)
    {
      if(analogRead(0) >= 400){
          valsum += analogRead(0);
      }
      Yacc += analogRead(YACC);
      Zacc += analogRead(ZACC);
    }

/*    if(YMAX <= analogRead(YACC))
    {
      YMAX = analogRead(YACC);
    }
    if(YMIN >= analogRead(YACC))
    {
      YMIN = analogRead(YACC);
    }
    if(ZMAX <= analogRead(ZACC))
    {
      ZMAX = analogRead(ZACC);
    }
    if(ZMIN >= analogRead(ZACC))
    {
      ZMIN = analogRead(ZACC);
    }
*/
    valave = valsum/AVERAGE;
    Yacc = Yacc /AVERAGE;
    Zacc = Zacc /AVERAGE;

    count++;
    if(count >= AVERAGE){
      count = 0;
    }
    
    analogWrite(LED,valave/4);
    delay(10);

    xinput = analogRead(XIN);
    yinput = analogRead(YIN);

//    for(int x = 0;x<=10;x++)
//    {
//      Yacc = analogRead(YACC);
//      Zacc = analogRead(ZACC);
//    }

//    Yacc = Yacc /10.0;
//    Zacc = Zacc /10.0;
    
    Serial.print(valave/4);
    Serial.print(",");
    Serial.print(Yacc);
    Serial.print(",");
    Serial.print(Zacc);
    Serial.print(",");
    Serial.println(button);

/*    Serial.print(",");
    Serial.print(YMAX);
    Serial.print(",");
    Serial.println(YMIN);
    Serial.print(",");
    Serial.print(ZMAX);
    Serial.print(",");
    Serial.println(ZMIN);
*/
//    if( == HIGH){
//      digitalWrite(LED,HIGH);
//      delay(val);
//    }else{
//      digitalWrite(LED,LOW);
//      delay(val);
//    }
}
