/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ArticleDto } from '../models/ArticleDto';
import type { CreateArticleDto } from '../models/CreateArticleDto';
import type { PaginatedResponse } from '../models/PaginatedResponse';
import type { Response } from '../models/Response';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class ArticlesService {
	/**
	 * @param requestBody
	 * @returns any Created
	 * @throws ApiError
	 */
	public static postApiArticles(
		requestBody?: CreateArticleDto,
	): CancelablePromise<any> {
		return __request(OpenAPI, {
			method: 'POST',
			url: '/api/articles',
			body: requestBody,
			mediaType: 'application/json',
			errors: {
				400: `Bad Request`,
			},
		});
	}
	/**
	 * @param pageNumber
	 * @param pageSize
	 * @param filterProperty
	 * @param filterValue
	 * @param orderBy
	 * @param isDescending
	 * @returns PaginatedResponse<ArticleDto> OK
	 * @throws ApiError
	 */
	public static getApiArticles(
		pageNumber?: number,
		pageSize?: number,
		filterProperty?: string,
		filterValue?: string,
		orderBy?: string,
		isDescending?: boolean,
	): CancelablePromise<PaginatedResponse<ArticleDto>> {
		return __request(OpenAPI, {
			method: 'GET',
			url: '/api/articles',
			query: {
				'PageNumber': pageNumber,
				'PageSize': pageSize,
				'FilterProperty': filterProperty,
				'FilterValue': filterValue,
				'OrderBy': orderBy,
				'IsDescending': isDescending,
			},
			errors: {
				400: `Bad Request`,
			},
		});
	}
	/**
	 * @param id
	 * @returns Response<ArticleDto> OK
	 * @throws ApiError
	 */
	public static getApiArticles1(
		id: string,
	): CancelablePromise<Response<ArticleDto>> {
		return __request(OpenAPI, {
			method: 'GET',
			url: '/api/articles/{id}',
			path: {
				'id': id,
			},
			errors: {
				400: `Bad Request`,
				404: `Not Found`,
				500: `Internal Server Error`,
			},
		});
	}
	/**
	 * @param id
	 * @returns void
	 * @throws ApiError
	 */
	public static deleteApiArticles(
		id: string,
	): CancelablePromise<void> {
		return __request(OpenAPI, {
			method: 'DELETE',
			url: '/api/articles/{id}',
			path: {
				'id': id,
			},
			errors: {
				400: `Bad Request`,
				404: `Not Found`,
			},
		});
	}
}
