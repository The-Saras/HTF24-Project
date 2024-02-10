import cv2
import mediapipe as mp
import requests

url = "http://127.0.0.1:8000/predict"

mp_hands = mp.solutions.hands.Hands()

cap = cv2.VideoCapture(0)

while cap.isOpened():
    ret,frame = cap.read()
    if not ret :
        break

    frame = cv2.flip(frame,1)

    rgb_frame = cv2.cvtColor(frame,cv2.COLOR_BGR2RGB)

    results = mp_hands.process(rgb_frame)

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            thumb_tip = hand_landmarks.landmark[4]
            index_tip = hand_landmarks.landmark[8]
            pinky_tip = hand_landmarks.landmark[20]
            midf_tip = hand_landmarks.landmark[12]
            ring_tip = hand_landmarks.landmark[16]
            midf_base = hand_landmarks.landmark[7]

            thumb_x , thumb_y = int(thumb_tip.x*frame.shape[1]),int(thumb_tip.y*frame.shape[0])
            index_x , index_y = int(index_tip.x*frame.shape[1]),int(index_tip.y*frame.shape[0])
            pinky_x , pinky_y = int(pinky_tip.x*frame.shape[1]),int(pinky_tip.y*frame.shape[0])
            midf_x , midf_y = int(midf_tip.x*frame.shape[1]),int(midf_tip.y*frame.shape[0])
            ring_x,ring_y = int(ring_tip.x*frame.shape[1]),int(ring_tip.y*frame.shape[0])
            midf_base_y = int(midf_base.y*frame.shape[1])

            if index_y < thumb_y and index_y < midf_y and index_y < pinky_y and index_y < ring_y:
                classified_gesture = 1
            elif midf_base_y > ring_y and midf_base_y > index_y:
                classified_gesture = 3
            elif index_y < thumb_y and index_y > midf_y and index_y < pinky_y and index_y < ring_y:
                classified_gesture=2
            else :
                classified_gesture=0
            processed_data = {"input":classified_gesture}
            response = requests.post(url,json=processed_data)
            cv2.putText(frame, f'Class: {classified_gesture}', (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    else :
        classified_gesture = 0
        processed_data = {"input":classified_gesture}
        response = requests.post(url,json=processed_data)

        cv2.putText(frame, f'Class: {classified_gesture}', (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    cv2.imshow("Hand Trackeing",frame)

    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
        

cap.release()
cv2.destroyAllWindows()
mp_hands.close()