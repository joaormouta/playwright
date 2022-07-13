Feature: Quote
    As a dealer
    I want to open the application

    Background: All test data intialised
        Given I have all test data for the POS MVP Quotes
	    Given I have all test data for the POS MVP Proposals

    @poss
    Scenario: Promote Quote to Proposal
        Given I am on the POS landing page as an external user
        When I submit my login details 'USERNAME1' and 'PASSWORD1'
        And I create the MVP Quote
        And I promote the quote to a proposal
        And I search for the MVP Pos proposal
        Then I should find WORKING Proposal as result
