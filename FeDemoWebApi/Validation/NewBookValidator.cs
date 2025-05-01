using FastEndpoints;
using FeDemoWebApi.DTO;
using FluentValidation;

namespace FeDemoWebApi.Validation;

public class NewBookValidator : Validator<NewBook>
{
	public NewBookValidator()
	{
		RuleForTitle();
		RuleForAuthor();
		RuleForDateOfPublication();
	}

	private void RuleForTitle()
	{
		var rule = RuleFor(b => b.Title);

		rule.NotEmpty()
			.WithMessage($"{nameof(NewBook.Title)} is required.");

		rule.MinimumLength(1)
			.WithMessage($"{nameof(NewBook.Title)} should be at least 1 characters long");

		rule.Matches(@"^\w")
			.WithMessage($"{nameof(NewBook.Title)} should begin with a word character.");
	}

	private void RuleForAuthor()
	{
		var rule = RuleFor(b => b.Author);

		rule.NotEmpty()
		    .WithMessage($"{nameof(NewBook.Author)} is required.");

		rule.MinimumLength(1)
		    .WithMessage($"{nameof(NewBook.Author)} should be at least 1 characters long");

		rule.Matches(@"^\w")
		    .WithMessage($"{nameof(NewBook.Author)} should begin with a word character.");
	}

	private void RuleForDateOfPublication()
	{
		var rule = RuleFor(b => b.DateOfPublication);

		rule.NotEmpty()
			.WithMessage($"{nameof(NewBook.DateOfPublication)} is required.");

		rule.LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
			.WithMessage($"{nameof(NewBook.DateOfPublication)} should be less than or equal to today.");
	}
}
