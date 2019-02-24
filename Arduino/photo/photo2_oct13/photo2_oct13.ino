const int AVERAGE = 150;
const int LED = 9;
const int XIN = 1;
const int YIN = 2;

//int val = 0;
long val[AVERAGE]={};
long valsum = 0;
long xinput = 0;
long yinput = 0;

double valave = 0;
int count = 0;
//int state = 0;
//int LEDstate = 0;

void setup(){
  pinMode(LED,OUTPUT);    //13Pinを出力にする
  Serial.begin(9800);     //モニター出力
//  pinMode(BUTTON,INPUT);  //12Pinを入力にする
}
void loop(){
//  digitalWrite(LED,HIGH);
//  delay(1000);
//  digitalWrite(LED,LOW);
//  delay(1000);

    valsum = valsum - val[count];
    val[count] = analogRead(0);
    if(val[count] <= 400){
      val[count] = 0;
    }
    valsum = valsum + val[count];
    valave = valsum / AVERAGE;

    count++;
    if(count >= AVERAGE){
      count = 0;
    }
    
    analogWrite(LED,valave/4);
    delay(10);

    xinput = analogRead(XIN);
    yinput = analogRead(YIN);
    
    Serial.print(valave/4);
    Serial.print(",");
    Serial.print(xinput);
    Serial.print(",");
    Serial.println(yinput);
//    if( == HIGH){
//      digitalWrite(LED,HIGH);
//      delay(val);
//    }else{
//      digitalWrite(LED,LOW);
//      delay(val);
//    }
}
