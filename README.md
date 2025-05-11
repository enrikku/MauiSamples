# 📱 .NET MAUI Android Utility Samples

This project is a collection of practical examples showcasing common Android utilities built with **.NET MAUI**. It's ideal for learning and integrating system-level features into your own apps.

---

## 🧩 Features

### ✅ Custom Popups
- Using `CommunityToolkit.Maui.Views.Popup`.
- Collect input from popups and return values to the caller.

### ✅ Barcode & QR Code Scanning/Generation (ZXing)
- Scan barcodes and QR codes using the device camera.
- Generate and display QR codes in the UI.

### ✅ ToDo App with SQLite
- Full CRUD implementation for managing tasks.
- Uses `SQLiteAsyncConnection` for local storage.

### ✅ Fingerprint Authentication
- Biometric authentication using the `Plugin.Fingerprint` package.
- Supports fingerprint and other available biometric methods.

### ✅ Broadcast Receivers
- Examples of native Android broadcast receivers:
  - Network connectivity changes.
  - Battery charging state.
  - Battery level (one-time check).
- Dynamically registered in `MainActivity`.

### ✅ Speech to Text
- Voice recognition using Android’s native `SpeechRecognizer`.
- Convert spoken input to text without cloud services.

---

## 🚀 Requirements

- .NET MAUI (.NET 8 or newer)
- Android 6.0 (API 23+) or newer
- Required permissions in `AndroidManifest.xml`:
  - `CAMERA`
  - `RECORD_AUDIO`
  - `USE_BIOMETRIC`
  - `INTERNET` (optional, for certain features)

---

## ✨ Author

Built by **Enric** as a learning and reference project.
