# TextBookAR-Hackwars
 Gamified AR Educational Platform built on Unity

An innovative Unity-based augmented reality application that brings NCERT books to life. Using images from NCERT textbooks as markers, this app spawns interactive 3D models or prefabs, allowing students to learn concepts in a more engaging and immersive way.  

## Screenshots

![Heart](https://github.com/user-attachments/assets/6242b073-798c-4b04-a80c-5f3f4dd18c64)
![neuron](https://github.com/user-attachments/assets/900e1a14-8660-46d7-9556-fcfef438d8fa)


## 🎯 Features  
- **Image Tracking:** Detect and track specific pages or diagrams in NCERT books using ARFoundation.  
- **Prefab Interaction:** Spawn 3D models, animations, or interactive elements mapped to the detected images.  
- **Gamification:** Get XP for each Easter Egg found, along with maintaining a collection of the ones found. 
- **Enhanced Learning:** Add an engaging AR layer to subjects like science, geography, and more.  

## 🛠️ Tech Stack  
- **Unity:** The core engine used to develop the app.
-  **C#:** Backend Scripting.
-  **Blender:** 3D Models.   
- **ARFoundation:** For cross-platform AR development (compatible with ARKit and ARCore).  


## 🖥️ Setup Instructions  

### Prerequisites  
- Unity 2021.3 LTS or later.  
- ARFoundation 4.2 or later.  
- ARKit/ARCore-compatible device.  

### Steps to Run  
1. **Clone the Repository:**  
   ```bash  
   git clone https://github.com/ISTE-VIT/TextBookAR.git
   cd TextBookAR
   ```  

2. **Open in Unity:**  
   - Open the project folder in Unity Hub.  
   - Make sure the correct Unity version is installed.  

3. **Configure AR Settings:**  
   - Go to **Edit > Project Settings > XR Plug-in Management** and enable ARKit and/or ARCore depending on your platform.  

4. **Build and Deploy:**  
   - For Android: Set the build target to Android and ensure the minimum API level is 24 or higher.  
   - For iOS: Set the build target to iOS and ensure ARKit is enabled.  

5. **Run the App:**  
   - Scan an NCERT image using your device camera, and watch the magic unfold!  

## 🎨 Contributing  
Contributions are welcome!  
- Found a bug? Open an issue. 
- Have a feature request? Feel free to fork the repository and create a pull request.  

## 📜 License  
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.  
