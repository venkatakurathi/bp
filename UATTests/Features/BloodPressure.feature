Feature: Blood Pressure Calculation
    In order to determine the category of blood pressure
    As a user
    I want to input systolic and diastolic values and get the corresponding category

    Scenario: Low Blood Pressure
        Given the systolic value is below 90 and diastolic value is below 60
        When I calculate the blood pressure category
        Then the result should be Low

    Scenario: Ideal Blood Pressure
        Given the systolic value is 100 and the diastolic value is 70
        When I calculate the blood pressure category
        Then the result should be Ideal

    Scenario: Pre-High Blood Pressure
        Given the systolic value is between 120 and 139 or diastolic value is between 80 and 89
        When I calculate the blood pressure category
        Then the result should be PreHigh

    Scenario: High Blood Pressure
        Given the systolic value is between 140 and 190 or diastolic value is between 90 and 100
        When I calculate the blood pressure category
        Then the result should be High

