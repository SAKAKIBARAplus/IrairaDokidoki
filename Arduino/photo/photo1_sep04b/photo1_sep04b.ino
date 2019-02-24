const int LED = 9;
int val = 0;
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

    val = analogRead(0);


    analogWrite(LED,val/4);
    delay(100);
    Serial.println(val/4);
//    if( == HIGH){
//      digitalWrite(LED,HIGH);
//      delay(val);
//    }else{
//      digitalWrite(LED,LOW);
//      delay(val);
//    }
}
