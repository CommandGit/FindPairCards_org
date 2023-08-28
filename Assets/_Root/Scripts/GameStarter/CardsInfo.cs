
using Extension;
using System;
using System.Collections.Generic;
using UnityEngine;

internal sealed class CardsInfo
{
    public int CardsCount;
    public int FieldWidth;
    public int FieldHeight;
    public Card[] Cards;
    public int CardsCountOnField;

    public CardsInfo(int levelNumber)
    {
        int cardsCount = GetCardsCountFromLevelNumber(levelNumber);
        CardsCountOnField = 0;
        CardsCount = cardsCount;
        Cards = new Card[cardsCount];
        for (int i = 0; i < cardsCount; i++)
        {
            Cards[i] = new Card();
        }

        SetRandomPair();
    }

    private int GetCardsCountFromLevelNumber(int levelNumber)
    {
        return 2 + (2 * levelNumber);
    }

    public void RemoveCard(Card card, CardView cardView)
    {
        for (int i = 0; i < CardsCount; i++)
        {
            if (Cards[i] == card)
            {
                Cards[i] = null;
            }
        }
    }

    private void SetRandomPair()
    {
        List<int> numbers = new List<int>();
        int countNumbers = CardsCount / 2;
        for (int i = 1; i <= countNumbers; i++)
        {
            numbers.Add(i);
            numbers.Add(i);
        }

        for (int i = 0; i < CardsCount; i++)
        {
            int randomNumber = numbers.GetRandomAndRemove();
            Cards[i].Number = randomNumber;
        }
    }

    public void CalculateDimension(float cardsZoneRatio, float cardRatio)
    {
        int s = 0;
        int count = CardsCount;
        int kx;
        int ky;

        do
        {
            float x = Mathf.Sqrt(count * cardRatio / cardsZoneRatio);

            kx = Mathf.FloorToInt(x);

            ky = Mathf.FloorToInt(x * cardsZoneRatio / cardRatio);

            s = kx * ky;

            count++;

        } while (s < CardsCount);

        int sumNormal = kx * ky;
        FieldWidth = kx;
        FieldHeight = ky;

        int sumX = (kx - 1) * ky;
        if (sumX < sumNormal && sumX >= CardsCount)
        {
            FieldWidth = kx - 1;
            FieldHeight = ky;
            sumNormal = sumX;
        }

        int sumY = kx * (ky - 1);
        if (sumY < sumNormal && sumY >= CardsCount)
        {
            FieldWidth = kx;
            FieldHeight = ky - 1;
            sumNormal = sumY;
        }
    }

    public void UpdateCardsTargetPosition(ZonePosition CardZonePosition)
    {
        List<CardPosition> positions = CalculatePositions(CardZonePosition);

        for (int i = 0; i < CardsCount; i++)
        {
            if (Cards[i] != null)
            {
                Cards[i].TargetPosition = new Vector3(positions[i].WorldPositionX, positions[i].WorldPositionY, 0f);
                Cards[i].ArrayPosition = new Vector2Int(positions[i].ArrayPositionX, positions[i].ArrayPositionX);
            }
        }
    }

    public void UpdateCardsTargetScale(ZonePosition CardZonePosition)
    {
        float dx = (CardZonePosition.MaxPosition.x - CardZonePosition.MinPosition.x) / FieldWidth;
        float dy = (CardZonePosition.MaxPosition.y - CardZonePosition.MinPosition.y) / FieldHeight;

        float scale = MathF.Min(dx / 1f, dy / 1.5f) * 0.9f;

        for (int i = 0; i < CardsCount; i++)
        {
            if (Cards[i] != null) Cards[i].TargetScale = scale;
        }
    }

    public void UpdateCardsStartPosition(Vector3 startPosition)
    {
        for (int i = 0; i < CardsCount; i++)
        {
            if (Cards[i] != null) Cards[i].StartPosition = startPosition + i * Vector3.left;
        }
    }

    private List<CardPosition> CalculatePositions(ZonePosition CardZonePosition)
    {
        List<CardPosition> positions = new List<CardPosition>();

        float dx = (CardZonePosition.MaxPosition.x - CardZonePosition.MinPosition.x) / FieldWidth;
        float dy = (CardZonePosition.MaxPosition.y - CardZonePosition.MinPosition.y) / FieldHeight;

        int count = 0;

        for (int y = 0; y < FieldHeight; y++)
        {
            for (int x = 0; x < FieldWidth; x++)
            {
                float xPosition = CardZonePosition.MinPosition.x + (dx / 2f) + x * dx;
                float yPosition = CardZonePosition.MinPosition.y + (dy / 2f) + y * dy;
                CardPosition cardPosition = new CardPosition(xPosition, yPosition, x, y);
                positions.Add(cardPosition);
                count++;
                if (count >= CardsCount) return positions;
            }
        }

        return positions;
    }

    public void OnScreenDataChanged(ScreenData screenData)
    {
        CalculateDimension(GetZoneRatio(screenData.ZonePositions.Cards), 1.5f);
        UpdateCardsTargetPosition(screenData.ZonePositions.Cards);
        UpdateCardsTargetScale(screenData.ZonePositions.Cards);

        Vector3 CardsStartPosition = CaclulateCardsStartPosition(screenData);
        UpdateCardsStartPosition(CardsStartPosition);
    }

    private float GetZoneRatio(ZonePosition zonePosition)
    {
        float dx = Mathf.Abs(zonePosition.MaxPosition.x - zonePosition.MinPosition.x);
        float dy = Mathf.Abs(zonePosition.MaxPosition.y - zonePosition.MinPosition.y);
        return dy / dx;
    }

    private Vector3 CaclulateCardsStartPosition(ScreenData screenData)
    {
        float dx = Mathf.Abs(screenData.ZonePositions.FullScreen.MinPosition.x - screenData.ZonePositions.FullScreen.MaxPosition.x);
        float dy = Mathf.Abs(screenData.ZonePositions.FullScreen.MinPosition.y - screenData.ZonePositions.FullScreen.MaxPosition.y);

        float newX = screenData.ZonePositions.FullScreen.MinPosition.x - dx;
        float newY = 0;
        float newZ = 0;

        return new Vector3(newX, newY, newZ);
    }
}

internal sealed class CardPosition
{
    public float WorldPositionX;
    public float WorldPositionY;
    public int ArrayPositionX;
    public int ArrayPositionY;

    public CardPosition(float worldPositionX, float worldPositionY, int arrayPositionX, int arrayPositionY)
    {
        WorldPositionX = worldPositionX;
        WorldPositionY = worldPositionY;
        ArrayPositionX = arrayPositionX;
        ArrayPositionY = arrayPositionY;
    }
}

internal sealed class Card
{
    public int Number;
    public Vector3 TargetPosition;
    public Vector3 StartPosition;

    public float CurrentYAngle;
    public float TargetYAngle;

    public float CurrentScale;
    public float TargetScale;

    public Vector2Int ArrayPosition;

    public Card()
    {
        CurrentScale = 1.0f;
        TargetScale = 1.0f;
    }
}

