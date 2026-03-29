# SignGuide AR

SignGuide AR is a mixed reality prototype for beginner sign language practice built for Meta Quest 3. Instead of learning from a flat image or video, users see a ghost hand in front of them and match their own tracked hand to it in 3D space.

The goal is to make sign learning feel more intuitive, spatial, and accessible by turning it into an interactive embodied experience.

## Features

- Passthrough mixed reality on Meta Quest 3
- Live hand tracking
- Ghost hand target poses for signs
- Fingertip-based pose matching
- In-headset feedback when a sign is matched
- Support for multiple signs

## How It Works

The user sees a virtual target hand floating in front of them representing a sign. Their real hand is tracked and rendered in the scene. The system compares the live fingertip positions of the tracked hand against target fingertip markers on the ghost hand. When the hand is aligned closely enough, the app reports a match.

## Tech Stack

- Unity
- C#
- Meta Quest 3
- Meta XR SDK
- Meta XR Interaction SDK
- OpenXR
- Passthrough mixed reality
- Hand tracking
- TextMeshPro
- Unity UI
- Git / GitHub

## Inspiration

Sign language is physical and spatial, but most beginner learning tools are still flat. We wanted to explore whether mixed reality could make sign practice more intuitive by letting users directly compare their own hand against a 3D target in real space.

## Challenges

One of the biggest challenges was the XR setup and build pipeline. Getting Unity, OpenXR, passthrough, hand tracking, and Meta XR packages all working together under hackathon time pressure took significant effort. We also had to carefully scope the problem. Full sign language recognition is much larger than a hackathon prototype, so we focused on a believable and interactive proof of concept based on fingertip pose alignment.

## Accomplishments

We are proud that we were able to build a real mixed reality prototype that:
- runs on Quest 3
- uses live hand tracking
- visualizes a target hand pose
- compares fingertip alignment in real time
- demonstrates multiple signs in a spatial learning context

## Future Work

- Add more signs
- Improve hand model polish and ghost hand presentation
- Provide per-finger feedback on mistakes
- Improve sign navigation and lesson flow
- Expand from pose matching into more robust sign recognition

## Repository Structure

This repository contains the Unity project for SignGuide AR, including:
- scene setup
- sign ghost hand poses
- matching scripts
- UI
- Meta XR project configuration

## Running the Project

1. Open the project in Unity
2. Ensure the Meta XR and Android build dependencies are installed
3. Connect a Meta Quest headset in developer mode
4. Build and run to Meta Quest 3

## Demo

This project was built as a hackathon prototype to demonstrate the core interaction loop:
**see the sign, match the hand, receive feedback.**

## Authors

Built by the SignGuide AR team at a hackathon.
